#include "matriz3d.h"

Matriz3D::Matriz3D()
{
    for (int k = 0; k < 4; k++)
        for (int l = 0; l < 4; l++)
        {
            if (k == l)
                datos[k][l] = 1;
            else
                datos[k][l] = 0;
        }
}

Matriz3D::Matriz3D(float A, float B, float C, float D, float E, float F, float G, float H, float I, float J, float K, float L)
{
    datos[0][0] = A;
    datos[0][1] = B;
    datos[0][2] = C;
    datos[0][3] = D;
    datos[1][0] = E;
    datos[1][1] = F;
    datos[1][2] = G;
    datos[1][3] = H;
    datos[2][0] = I;
    datos[2][1] = J;
    datos[2][2] = K;
    datos[2][3] = L;
    datos[3][0] = 0;
    datos[3][1] = 0;
    datos[3][2] = 0;
    datos[3][3] = 1;
}

void Matriz3D::setDato(int f, int c, float d)
{
    datos[f][c] = d;
}

float Matriz3D::getDato(int f, int c)
{
    return datos[f][c];
}

Matriz3D* Matriz3D::copia()
{
    Matriz3D*N = new Matriz3D();
    for (int k = 0; k < 3; k++)
        for (int l = 0; l < 4; l++)
            N->setDato(k, l, datos[k][l]);
    return N;
}

Matriz3D* Matriz3D::mult(Matriz3D* m)
{
    float s = 0;
    Matriz3D* Res = new Matriz3D();
    for (int f = 0; f < 4; f++)
        for (int c = 0; c < 4; c++)
        {
            s = this->getDato(f, 0)*m->getDato(0, c);
            s += this->getDato(f, 1)*m->getDato(1, c);
            s += this->getDato(f, 2)*m->getDato(2, c);
            s += this->getDato(f, 3)*m->getDato(3, c);
            Res->setDato(f, c, s);
        }
    delete m;
    return Res;
}
