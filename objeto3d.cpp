#include "objeto3d.h"

Objeto3D::Objeto3D()
{

}

void Objeto3D::rotar(Eje* e,float ang)
{
    float a=e->getp2->getx()-e->getp1()->getx();
    float b=e->getp2->gety()-e->getp1()->gety();
    float c=e->getp2->getz()-e->getp1()->getz();

    float alpha=atan(b/c);
    float d=sqrt(b*b+c*c);
    float beta=atan(a/d);

    Matriz3D mt1=new Matriz3D(1,0,0,-e->getp1->getx()
                            ,0,1,0,-e->getp1->gety()
                            ,0,0,1,-e->getp1->getz());

    Matriz3D mrx=new Matriz3D(1,0,0,0,
                            ,0,cos(alpha),-sin(alpha),0
                            ,0,sin(alpha),cos(alpha),0);
    Matriz3D mry=new Matriz3D(cos(-beta),0,sin(-beta),0
                            ,0,1,0,0
                            ,sin(-beta),0,cos(-beta));
    Matriz3D mrz=new Matriz3D(cos(ang),-sin(ang),0,0
                            ,sin(ang),cos(ang),0,0
                            ,0,0,1,0);

    mry2=+beta;
    mrx2=-alpha;
    mt2=+p1;

    Matriz3D * m = mt2->mult(mrx2->mult(mrxy2->mult(mrz->mult)));

}
