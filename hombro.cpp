#include "hombro.h"

Hombro::Hombro():Objeto3D()
{
    ejeVert=0;
    ejeHor=0;
}

Hombro::~Hombro()
{
    Superficie* s = s->getInicio();
    while(s!=0)
    {
        inicio=inicio->getSig();
        s->getInicio()=s->getInicio();
        delete s;
        s=inicio;
    }
    if(ejeVert!=0)
        delete ejeVert;
    if(ejeHor!=0)
        delete ejeHor;
}

void Hombro::setEjeVert(Eje *e)
{
    this->ejeVert=e;
}
Eje* Hombro::getEjeVert()
{
    return ejeVert;
}
void Hombro::setEjeHor(Eje *e)
{
    this->ejeHor=e;
}

Eje* Hombro::getEjeHor()
{
    return ejeHor;
}

Hombro* Hombro::copia()
{
    Hombro *copia = new Hombro();
    Superficie *s = s->getInicio();
    while(s!=0)
    {
        copia->agregar(s->copia);
        s->getSig();
    }
    return copia;
}

void Hombro::gira(float a)
{
    this->rotar(ejeVert,a);
    ejeHor->rotar(ejeVert,a);

}

void Hombro::mueve(float ang)
{
    this->rotar(ejeHor,ang);
}


