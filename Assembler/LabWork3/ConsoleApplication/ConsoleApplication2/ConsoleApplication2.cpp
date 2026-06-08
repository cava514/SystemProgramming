// ConsoleApplication2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>

int main()
{
    int n { 0 };
    std::cin >> n;
    int summ { 0 };
    int i = 0;
    for (; i <= n; i++)
    {
        summ += i;
    }
    std::cout << summ << std::endl;
}