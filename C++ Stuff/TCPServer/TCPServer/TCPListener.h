#pragma once
#pragma comment(lib,"ws2_32.lib")
#include <iostream>
#include <WS2tcpip.h>
#include <string>
#include <thread>

class TCPListener;

//callback for data receiver
typedef void(*MessageRecievedHandler)(TCPListener* listener, int socketID, std::string msg);

class TCPListener
{
public:
	//constructor
	TCPListener(std::string ipAdress,int port, MessageRecievedHandler handler);
	
	//destructor
	~TCPListener();

	//send a message to a client
	bool Send(int clientSocket, std::string msg);

	//send message to all clients,except the listener and the client that sent tha message
	void SendGlobal(int clientSocket, std::string msg);

	//initialize Winsock
	bool Init();

	//main running loop
	void RunInThread();

private:
	//private functions used 
	void Run();
	SOCKET CreateSocket();
	SOCKET WaitForConnection(SOCKET listening);

	//private variables
	SOCKET			m_listening_sock;
	bool			m_run_thread_running;
	std::thread		m_run_thread;
	std::string		m_ipAdress;			//IP address of the server
	int				m_port;				//listening port 
	fd_set			master;				//master file descriptor

	//function pointer to the callback
	MessageRecievedHandler MessageReceived;
};