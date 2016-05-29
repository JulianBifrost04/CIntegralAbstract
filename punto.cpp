#include "punto.h"

Punto::Punto()
{
    this->x = 0;
    this->y = 0;
    this->z = 0;
}

Punto::Punto(float x, float y, float z)
{
    this->x = x;
    this->y = y;
    this->z = z;
}

void Punto::trasladar(float xt, float yt)
{
    x = x + xt;
    y = y + yt;
}

float Punto::getX()
{
    return this->x;
}

void Punto::setX(float x)
{
    this->x = x;
}

float Punto::getY()
{
    return this->y;
}

void Punto::setY(float y)
{
    this->y = y;
}

float Punto::getZ()
{
    return this->z;
}

void Punto::setZ(float z)
{
    this->z = z;
}

Punto* Punto::copia()
{
    Punto *p = new Punto(x, y, z, color, intensidad);
    return p;
}
void Punto::trasladar(float x, float y, float z)
{
    this->x = this->x + x;
    this->y = this->y + y;
    this->z = this->z + z;
}

void Punto::escalar(float xf, float yf, float zf, float sx, float sy, float sz)
{
    x = (x - xf)*sx + xf;
    y = (y - yf)*sy + yf;
    z = (z - zf)*sz + zf;
}

void Punto::rotar(float xr, float yr, float zr, float ang)
{
    float xa = x;
    x = (x - xr)* cos(ang) - (y - yr)*sin(ang) + xr;
    y = (y - yr)*cos(ang) + (xa - xr)*sin(ang) + yr;
}

void Punto::transformar(Matriz3D *m){
    float x1, y1, z1;
    x1 = m->getDato(0, 0)*m->getDato(0, 1)*x + m->getDato(0, 2);
    y1 = m->getDato(1, 0)*m->getDato(1, 1)*y + m->getDato(1, 2);
    z1 = m->getDato(2, 0)*m->getDato(2, 1)*z + m->getDato(2, 2);

    x = x1;
    y = y1;
    z = z1;
}

bool Punto::seleccion(Punto*p)
{
    int x1 = p->getX();
    int y1 = p->getY();
    if (abs(x - x1) <= 10 && abs(y - y1) <= 10)
        return true;
    return false;
}
