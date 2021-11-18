/*******************************************************************************
Copyright (c) 2021 EducAR All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 
Projeto:
*****************************************************************************/


using System;
using System.Collections; 
public interface ISystem<T> where T: Enum  
{ 
    T Status
    {
        get;
    }
}
