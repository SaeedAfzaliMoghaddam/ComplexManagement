using System;
using System.Runtime.CompilerServices;
using Templete.Services.Complexes.Contracts;
using Templete.Services.Contracts;

public class ComplexAppService : ComplexService
{
    private readonly ComplexRepository _repository;
    private readonly UnitOfWork _unitOfWork;
    public ComplexAppService
        (
        ComplexRepository repository,
        UnitOfWork unitOfWork
        )
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public void Define(AddComplexDto dto)
    {
        var complex = new Complex
        {
            Name = dto.Name,
            UnitCapacity = dto.UnitCapacity,
        };

        _repository.Add(complex);
        _unitOfWork.Complete();

    }
}


