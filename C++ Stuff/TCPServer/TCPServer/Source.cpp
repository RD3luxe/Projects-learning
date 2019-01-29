#include"TCPListener.h"
#define SEC 5
#define PORT 54000
#define SERVER_IP "127.0.0.1"
using namespace std;

//the callback method
void Message_Receiver(TCPListener* listener, int client, string msg)
{
	//listener->Send(client, msg);
	string message;
	message = message + "SOCKET #" + to_string(client) + ": " + msg;
	listener->SendGlobal(client, message);
	cout << "SOCKET " << client << ": " << msg << "\n";
}

int main()
{
	string inputStr;
	TCPListener *server = new TCPListener(SERVER_IP, PORT, Message_Receiver);
	if (server->Init())
	{
		server->RunInThread();
		while (true)
		{
			getline(cin, inputStr);
			if (inputStr == "shutdown")
			{
				Sleep(60 * SEC);
				break;
			}
			inputStr += "\n";
			server->SendGlobal(NULL, inputStr);
		}
	}
	//this will automatically call the destructor
	delete server;
	return 0;
}