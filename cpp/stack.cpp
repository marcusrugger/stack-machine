#include "stack.h"
#include <stdexcept>




StackFIFO::StackFIFO(void) : StackFIFO(128) {}


StackFIFO::StackFIFO(unsigned int size)
:   _size(size),
    _sink_index(0),
    _source_index(0),
    _count(0),
    _stack(new double[size])
{}


StackFIFO::StackFIFO(const StackFIFO &other)
:   _size(other._size),
    _sink_index(other._sink_index),
    _source_index(other._source_index),
    _count(other._count),
    _stack(new double[_size])
{
    for (int i = _source_index; i != _sink_index; i = incrementIndex(i))
        _stack[i] = other._stack[i];
}


StackFIFO::StackFIFO(StackFIFO &&other)
:   _size(other._size),
    _sink_index(other._sink_index),
    _source_index(other._source_index),
    _count(other._count),
    _stack(other._stack)
{
    other._stack = NULL;
}


StackFIFO::~StackFIFO(void)
{
    if (_stack)
        delete [] _stack;
}


void StackFIFO::push(double value)
{
    if (_count < _size)
    {
        _stack[_sink_index] = value;
        _sink_index = incrementIndex(_sink_index);
        _count++;
    }
    else
        throw new std::out_of_range("Stack overflow");
}


double StackFIFO::pull(void)
{
    if (_count > 0)
    {
        double value = _stack[_source_index];
        _source_index = incrementIndex(_source_index);
        _count--;
        return value;
    }
    else
        throw new std::out_of_range("Stack underflow");
}




StackLIFO::StackLIFO(void) : StackLIFO(128) {}


StackLIFO::StackLIFO(unsigned int size)
:   _size(size),
    _index(0),
    _stack(new double[size])
{}


StackLIFO::StackLIFO(const StackLIFO &other)
:   _size(other._size),
    _index(other._index),
    _stack(new double[_size])
{
    for (int i = 0; i < _index; i++)
        _stack[i] = other._stack[i];
}


StackLIFO::StackLIFO(StackLIFO &&other)
:   _size(other._size),
    _index(other._index),
    _stack(other._stack)
{
    other._stack = NULL;
}


StackLIFO::~StackLIFO(void)
{
    if (_stack)
        delete [] _stack;
}


void StackLIFO::push(double value)
{
    if (_index < _size)
        _stack[_index++] = value;
    else
        throw new std::out_of_range("Stack overflow");
}


double StackLIFO::pull(void)
{
    if (_index > 0)
        return _stack[--_index];
    else
        throw new std::out_of_range("Stack underflow");
}
