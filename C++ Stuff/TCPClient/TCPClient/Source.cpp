#include "TCPClient.h"
#define PORT 54000
#define SERVER "127.0.0.1"
using namespace std;

void MessageReceived(string msg_received)
{
	//server can send message to the client here
	cout << msg_received << endl;
}

int main()
{
	string inputBuffer;
	TCPClient *client = new TCPClient();
	if (client->Connect(SERVER, PORT))
	{
		client->ListenRecvInThread(MessageReceived);
		while (true)
		{
			//get the input from client
			getline(cin, inputBuffer);
			if (inputBuffer == "/quit")
				break;

			client->Send(inputBuffer);
			cout << "YOU : ";
		}
	}
	return 0;
}