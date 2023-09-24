using System;

public interface IKeyboardInput
{
    string GetInput();
    event Action<char> KeyPressed;
    void StartListening();
}
