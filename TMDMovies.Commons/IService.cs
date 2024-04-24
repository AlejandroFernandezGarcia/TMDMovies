namespace TMDMovies.Commons
{
    public interface IService<Input, Output>
    {
        public Output Execute(Input input);
    }
}
