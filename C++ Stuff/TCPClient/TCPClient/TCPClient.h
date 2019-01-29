#pragma once
#pragma comment(lib,"ws2_32.lib")
#include<iostream>
#include<WS2tcpip.h>
#include<thread>
#include<string>

class TCPClient;

//callback to data received
typedef void(*MessageReceivedHandler)(std::string msg);

class TCPClient
{
public:
	//constructor
	TCPClient();

	//create the connection between server and client
	bool Connect(std::string serverIP,int port);

	//listen the server for updates
	void ListenRecvInThread(MessageReceivedHandler handler);

	//send a message to the server
	bool Send(std::string message);

	//destructor
	~TCPClient();
private:
	//private functions
	bool Init();
	SOCKET CreateSocket();
	void ThreadRecv();
	bool Recv(MessageReceivedHandler handler);

	//private variables
	std::string server_ip;
	int			server_port;
	SOCKET		m_socket;
	sockaddr_in m_hint;
	bool		m_recv_thread_running;
	std::thread m_recv_thread;

	//Message received event handler
	MessageReceivedHandler MessageReceived;
};

