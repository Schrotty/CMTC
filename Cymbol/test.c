#include <stdio.h>
#include <stdlib.h>

int f(int i, int j)
{
	return i + j;
}

int main(int argc, char *argv[])
{
	int i;
	i = atoi(argv[0]);
	printf("%s", argv[0]);

	return f(i, 21);
}