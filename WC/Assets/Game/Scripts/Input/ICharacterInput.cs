namespace WC
{
    public interface ICharacterInput
    {
        bool MoveLeft { get; }

        bool MoveRight { get; }

        bool Jump { get; }
        
        bool Kick { get; }
    }
}
