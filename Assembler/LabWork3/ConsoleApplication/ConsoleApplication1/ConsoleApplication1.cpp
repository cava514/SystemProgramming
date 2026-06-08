#include <iostream>

int main()
{
    int n { 0 };
    std::cin >> n;
    int summ { 0 };
    for (int i = 0; i <= n; i++)
    {
        summ += i;
    }
    std::cout << summ << std::endl;
}
