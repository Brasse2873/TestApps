#pragma once
#include <stdlib.h>

template <class T>
class MyDate
{
public:
	MyDate(void){};
	MyDate( T date, T time ): m_date(date), m_time(time){};
	~MyDate(void){};

	T time(){ return m_time; }
	T date(){ return m_date; }

	void setDateTime( char *date, char *time )
	{
		m_date = atoi( date );
		m_time = atoi( time );
	}

	int operator< ( MyDate<T> &date )
	{
		if( (m_date < date.date()) || (m_date == date.date()) && (m_time < date.time()) )
			return true;

		return false;
	}

	MyDate<T>& operator=( MyDate<T> &date )
	{
		m_date = date.date();
		m_time = date.time();
		return *this;
	}

private:
	T m_time;
	T m_date;
};

