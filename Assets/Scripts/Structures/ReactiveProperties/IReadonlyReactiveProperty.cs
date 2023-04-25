using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveProperties
{
    public interface IReadonlyReactiveProperty<out T>
    {
        T Value { get;  }
        void Subscribe(Action<T> valueChanged);
        void Unsubscribe(Action<T> valueChanged);
    }
}
