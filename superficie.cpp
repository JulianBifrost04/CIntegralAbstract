#include "superficie.h"

Superficie::Superficie()
{

}

void Superficie::agregar(Vertice* v)
{
    if (inicio == 0)
    {
        inicio = v;
        final = v;
    }
    else
    {
        final->setSig(v);
        final = v;
    }
    v->setSig(0);
}
