namespace Repository;

using System;
using System.Collections.Generic;
using Domain;
using Object = Domain.Object;

public interface IRepository<T> {
    public bool 		Create(T obj);
    public IEnumerable<T> 	Read();
    public Boolean 		Update(T obj);
    public bool 		Delete(T obj);
}
