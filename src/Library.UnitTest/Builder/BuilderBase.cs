using FizzWare.NBuilder;

namespace Library.UnitTest.Builder
{
    public abstract class BuilderBase<T>
    {
        protected ISingleObjectBuilder<T> _builderInstance;
        public BuilderBase()
        {
            LoadDefault();
        }

        protected abstract void LoadDefault();

        public T Build() => _builderInstance.Build();


        public ISingleObjectBuilder<T> With<TFunc>(Func<T, TFunc> func) => _builderInstance.With(func);


        public ISingleObjectBuilder<T> Do(Action<T> action) => _builderInstance.Do(action);
    }
}
