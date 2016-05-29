#include "brazo.h"

Brazo::Brazo()
{

}

void Brazo::copia()
{
    Brazo * b = new Brazo();
    b->setHombro(this->hombro->copia());
    b->setAntebrazo(this->antebrazo->copia());
    b->setPinza1(this->pinza1->copia());
    b->setPinza2(this->pinza2->copia());
    return b;


}
void Brazo::giraHombro(float a)
{
    hombro->gira(a);
    antebrazo->gira(hombro->getVert(),a);
    pinza1->gira(hombro->getVert(),a);
    pinza2->gira(hombro->getVert(),a);
}

void Brazo::moverHombro(float a)
{
    hombro->mover(a);
    antebrazo->mover(hombro->getEjeHor,a);
    pinza1->mover(hombro->getEjeHor,a);
    pinza2->mover(hombro->getEjeHor,a);
}
void Brazo::abrirPinzas(float a)
{
    pinza1->girar(a);
    pinza2->girar(-a);
}

void Brazo::cerrarPinzas(float a)
{
    pinza1->girar(-a);
    pinza2->girar(a);
}

void Brazo::moverAntebrazo(float a)
{
    antebrazo->mover(a);
    pinza1->mover(antebrazo->getEje(),a);
    pinza2->mover(antebrazo->getEje(),a);
}
void Brazo::desplegar()
{
    hombro->desplegar();
    antebrazo->desplegar();
    pinza1->desplegar();
    pinza2->desplegar();
}
