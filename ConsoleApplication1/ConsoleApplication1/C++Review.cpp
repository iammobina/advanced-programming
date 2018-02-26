#include <iostream>
using namespace std;
int main(int argc, char* argv[])
{
	while (true)
	{
		char* charr = new char[1000];
		//Sleep(1);
		delete[] charr;
	}
	return 0;
}