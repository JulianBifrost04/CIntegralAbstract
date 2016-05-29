#include "vertice.h"

Vertice::Vertice()
{
    this->x = 0;
    this->y = 0;
    this->y = 0;
}
Vertice::Vertice(float x, float y, float z):Punto(x,y,z)
{
    sig=0;
}

Vertice* Vertice::Copia()
{
    Vertice* v = new Vertice(this->x,this->y,this->z);
    return v;
}
Vertice* Vertice::getSig()
{
    return sig;
}
void Vertice::setSig(Vertice* V)
{
    sig = V;
}

void Vertice::transformar(Matriz3D *m)
{
    float x1 = 0, y1 = 0, z1 = 0;
    x1 = m->getDato(0, 0)*x + m->getDato(0, 1)*y + m->getDato(0, 2)*z + m->getDato(0, 3);
    y1 = m->getDato(1, 0)*x + m->getDato(1, 1)*y + m->getDato(1, 2)*z + m->getDato(1, 3);
    z1 = m->getDato(2, 0)*x + m->getDato(2, 1)*y + m->getDato(2, 2)*z + m->getDato(2, 3);

    x = x1;
    y = y1;
    z = z1;
}
