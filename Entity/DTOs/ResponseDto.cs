﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs;

public class ResponseDto<T> : ResponseDto
{    
    public T Data { get; set; }
}
public class ResponseDto
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }
}
