#include "TCPClient.h"
#define DIM_BUFFER 4096

//constructor
TCPClient::TCPClient()
{
	m_socket = INVALID_SOCKET;
	m_recv_thread_running = false;
}

//destructor
TCPClient::~TCPClient()
{
	closesocket(m_socket);
	WSACleanup();
	if (m_recv_thread_running)
	{
		m_recv_thread_running = false;
		m_recv_thread.join();
	}
}

//initialize the winsock
bool TCPClient::Init()
{
	system("color 9");
	WSADATA data;
	WORD ver = MAKEWORD(2, 2);
	int wsInit = WSAStartup(ver, &data);
	if (wsInit != 0)
	{
		std::cerr << "Error, can't start winsock." << std::endl;
		return false;
	}
	return wsInit == 0;
}

//make the connection with the server
bool TCPClient::Connect(std::string serverIP, int port)
{
	server_ip = serverIP;
	server_port = port;

	//initialize winsock
	if (!Init())
		return false;

	//create the socket for the client to send and receive
	m_socket = CreateSocket();
	if (m_socket == INVALID_SOCKET)
		return false;

	//connect the client to the server
	int connResult = connect(m_socket, (sockaddr*)&m_hint, sizeof(m_hint));
	if (connResult == SOCKET_ERROR)
	{
		std::cerr << "Can't connect to server ..." << std::endl;
		return false;
	}
	return true;
}

//function to create a socket
SOCKET TCPClient::CreateSocket()
{
	SOCKET sock_client = socket(AF_INET, SOCK_STREAM, 0);
	if (sock_client != INVALID_SOCKET)
	{
		//fill in a hint structure
		m_hint.sin_family = AF_INET;
		m_hint.sin_port = htons(server_port);
		inet_pton(AF_INET, server_ip.c_str(), &m_hint.sin_addr);
	}
	else 
	{
		std::cerr << "Error,couldn't create socket. " << WSAGetLastError() << std::endl;
		WSACleanup();
	}
	return sock_client;
}

//function for message
bool TCPClient::Send(std::string message)
{
	if (!message.empty() && m_socket != INVALID_SOCKET)
	{
		return send(m_socket, message.c_str(), message.size() + 1, 0) != SOCKET_ERROR;
	}
	return false;
}

//function that opens a thread and keeps the connection client - server opened
void TCPClient::ListenRecvInThread(MessageReceivedHandler handler)
{
	MessageReceived = handler;
	this->m_recv_thread = std::thread([&]()
	{
		ThreadRecv();
	});
}

//the actual connection client - server
void TCPClient::ThreadRecv()
{
	//start the thread
	m_recv_thread_running = true;
	while (m_recv_thread_running)
	{
		char buffer[DIM_BUFFER];
		memset(buffer, 0, DIM_BUFFER);
		int bytesReceived = recv(m_socket, buffer, DIM_BUFFER, 0);
		if (bytesReceived > 0)
		{
			if (MessageReceived != NULL)
			{
				MessageReceived(std::string(buffer, 0, bytesReceived));
			}
		}
	}
}

//used after we kill the thread
bool TCPClient::Recv(MessageReceivedHandler handler)
{
	MessageReceived = handler;
	if (m_socket == INVALID_SOCKET)
		return false;

	char buffer[DIM_BUFFER];
	memset(buffer, 0, DIM_BUFFER);
	int bytesReceived = recv(m_socket, buffer, DIM_BUFFER, 0);
	if (bytesReceived > 0)
	{
		if (MessageReceived != NULL)
		{
			MessageReceived(std::string(buffer, 0, bytesReceived));
		}
	}
	return true;
}