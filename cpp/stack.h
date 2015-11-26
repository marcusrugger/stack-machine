#ifndef STACK_H
#define STACK_H

#include <stdexcept>


template <typename T>
class Cloneable
{
public:

    virtual T *clone(void) const = 0;

};


class Stack : public Cloneable<Stack>
{
public:

    ~Stack(void) {}

    virtual void push(double d) = 0;
    virtual double pull(void)   = 0;

    virtual bool isMore(void)   const = 0;

    virtual Stack *clone(void)  const = 0;

};


class StackFIFO : public Stack
{
private:

    const unsigned int _size;
    unsigned int _sink_index;
    unsigned int _source_index;
    unsigned int _count;
    double *_stack;


    inline unsigned int incrementIndex(unsigned int index)
    { return index < _size ? index+1 : 0; }


public:

    StackFIFO(void);
    StackFIFO(unsigned int size);
    StackFIFO(const StackFIFO &other);
    StackFIFO(StackFIFO &&other);

    ~StackFIFO(void);


public:

    void push(double d);
    double pull(void);

    bool isMore(void) const { return _count > 0; }

    Stack *clone(void) const { return new StackFIFO(*this); }

};


class StackLIFO : public Stack
{
private:

    const unsigned int _size;
    unsigned int _index;
    double *_stack;


public:

    StackLIFO(void);
    StackLIFO(unsigned int size);
    StackLIFO(const StackLIFO &other);
    StackLIFO(StackLIFO &&other);

    ~StackLIFO(void);


public:

    void push(double d);
    double pull(void);

    bool isMore(void) const { return _index > 0; }

    Stack *clone(void) const { return new StackLIFO(*this); }

};


#endif // STACK_H
