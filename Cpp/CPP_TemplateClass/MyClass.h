#pragma once

template <class T>
class MyClass
{
public:
	MyClass(void);
	~MyClass(void);
	T var;
};

template <class T>
MyClass<T>::MyClass(void)
{
}

template <class T>
MyClass<T>::~MyClass(void)
{
}
