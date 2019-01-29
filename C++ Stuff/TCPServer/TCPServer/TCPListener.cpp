#include "TCPListener.h"
#define MAX_BUFFER 41942

//constructor
TCPListener::TCPListener(std::string ipAdress, int port, MessageRecievedHandler handler)
	: m_ipAdress(ipAdress), m_port(port), MessageReceived(handler)
{
	//initialize 
	FD_ZERO(&master);
	m_run_thread_running = false;
}

//destructor
TCPListener::~TCPListener()
{
	//message
	std::string message = "Server is shutting down.\n";
	//close all sockets
	while (master.fd_count > 0)
	{
		//get the socket number
		SOCKET sock = master.fd_array[0];
		
		//send a message 
		send(sock, message.c_str(), message.size() + 1, 0);

		//remove it from the master file list and close the socket
		FD_CLR(sock, &master);
		closesocket(sock);
	}

	//close the listening socket and clean winsock
	closesocket(m_listening_sock);
	WSACleanup();

	//finish running thread
	if (m_run_thread_running)
	{
		m_run_thread_running = false;
		m_run_thread.join();
	}
}

//function for initializing winsock
bool TCPListener::Init()
{
	system("color 2");
	WSADATA data;

	WORD ver = MAKEWORD(2, 2);
	int wsInit = WSAStartup(ver, &data);
	if (wsInit != 0)
	{
		std::cerr << "Error can't open the server." << std::endl;
		return false;
	}
	return wsInit == 0;
}

//function for creating a socket
SOCKET TCPListener::CreateSocket()
{
	SOCKET listening = socket(AF_INET, SOCK_STREAM, 0);
	if (listening != INVALID_SOCKET)
	{
		// Fill a hint structure
		sockaddr_in hint;
		hint.sin_family = AF_INET;
		hint.sin_port = htons(m_port);
		inet_pton(AF_INET, m_ipAdress.c_str(), &hint.sin_addr);

		// bint the ip adress and port to a socket
		int bindOk = bind(listening, (sockaddr*)&hint, sizeof(hint));
		if (bindOk != SOCKET_ERROR)
		{
			int listenOk = listen(listening, SOMAXCONN);
			if (listenOk == SOCKET_ERROR)
			{
				std::cerr << "Can't listen to socket, Err #" << WSAGetLastError() << std::endl;
				return -1;
			}
		}
		else
		{
			std::cerr << "Can't bind to socket, Err #" << WSAGetLastError() << std::endl;
			return -1;
		}
	}
	else
	{
		std::cerr << "Can't create socket, Err #" << WSAGetLastError() << std::endl;
		WSACleanup();
	}
	return listening;
}

//accept connection from a client and return him
SOCKET TCPListener::WaitForConnection(SOCKET listening)
{
	SOCKET client = accept(listening, nullptr, nullptr);
	return client;
}

//send brodcast messages
bool TCPListener::Send(int clientSocket, std::string msg)
{
	if (!msg.empty())
	{
		return send(clientSocket, msg.c_str(), msg.size() + 1, 0) != SOCKET_ERROR;
	}
	return false;
}

//send message to all clients except for the client that send the message
void TCPListener::SendGlobal(int clientSocket, std::string msg)
{
	if (!msg.empty())
	{
		for (unsigned int i = 0; i < master.fd_count; i++)
		{
			SOCKET outSock = master.fd_array[i];
			if((outSock != m_listening_sock) && (outSock != clientSocket))
			{
				send(outSock, msg.c_str(), msg.size() + 1, 0);
			}
		}
	}
}

//Server loop thread
void TCPListener::RunInThread()
{
	this->m_run_thread = std::thread([&]()
	{
		Run();
	});
}

void TCPListener::Run()
{
	// create a listening socket 
	m_listening_sock = CreateSocket();
	if (m_listening_sock == INVALID_SOCKET)
	{
		std::cerr << "Error in Run() when creating socket." << std::endl;
		return;
	}

	FD_SET(m_listening_sock, &master);
	m_run_thread_running = true;

	std::cout << "Server is running ! \nWaiting for connections ...\n";
	while (m_run_thread_running)
	{
		fd_set copy = master;
		int socketCount = select(0, &copy, nullptr, nullptr, nullptr);
		
		//loop through all the current connections
		for (int i = 0; i < socketCount; i++)
		{
			// wait for a connection
			SOCKET sock = copy.fd_array[i];
			if (sock == m_listening_sock)
			{
				//accept a new connecton
				SOCKET client = WaitForConnection(m_listening_sock);

				//add the new connection to the list of connected clients
				FD_SET(client, &master);

				//send a message
				std::string welcomeMsg = "Welcome !!!";
				send(client, welcomeMsg.c_str(), welcomeMsg.size() + 1, 0);
			}
			else
			{
				char buffer[MAX_BUFFER];
				memset(buffer, 0, MAX_BUFFER);

				//receive message
				int bytesIn = recv(sock, buffer, MAX_BUFFER, 0);
				if (bytesIn <= 0)
				{
					closesocket(sock);
					FD_CLR(sock, &master);
				}
				else
				{
					if (buffer[0] == '/')
					{
						//impement the command
						std::string cmd = std::string(buffer, bytesIn);
						if (cmd.compare("/quit") == 0)
						{
							m_run_thread_running = false;
							break;
						}
						//unknown command
						continue;
					}
					if (MessageReceived != NULL)
					{
						MessageReceived(this, sock, std::string(buffer, 0, bytesIn));
					}
				}
			}
		}
	}

	FD_CLR(m_listening_sock, &master);
	std::string msg = "Server is shutting down ...\n";

	while (master.fd_count > 0)
	{
		//get the socket number
		SOCKET sock = master.fd_array[0];
		//send the message to all clients
		send(sock, msg.c_str(), msg.size() + 1, 0);
		//remove it from the master file list and close the socket
		FD_CLR(sock, &master);
		closesocket(sock);
	}
}