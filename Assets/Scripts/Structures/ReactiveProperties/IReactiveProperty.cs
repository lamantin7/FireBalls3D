using ReactiveProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures.ReactiveProperties
{
    public interface IReactiveProperty<T>:IReadonlyReactiveProperty<T>
    {
        void Change(T value);
    }
    public class FakeReactiveProperty<T> : IReactiveProperty<T>
    {
        public T Value => throw new NotImplementedException();

        public void Change(T value)
        {
           
        }

        public void Subscribe(Action<T> valueChanged)
        {
            
        }

        public void Unsubscribe(Action<T> valueChanged)
        {
            
        }
    }
}
