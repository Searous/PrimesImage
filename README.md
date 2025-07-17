# Description
A small C# program I wrote for fun that generates an image which shows prime numbers as yellow pixels.

Generates an image called 'primes.png' in the folder the program is run from. Yellow dots represent primes, grey dots represent numbers that aren't prime. The count starts from the top left at 1, count up by 1 going across to the right, wrapping at the edge.

![vlc_cahFdUqajx](https://github.com/user-attachments/assets/6e8f65f2-f9db-4899-be12-53ad4f9c0f8d)

# Running
Download the executable from the releases section. Double click to run. A command window will apear. Follow the prompts to generate your image.

# Building
Clone the repo like so: 
```
git clone https://github.com/Searous/PrimesImage.git
```
Build the project using the .NET SDK (the release was built using .NET8.0, but anything .NET6.1 and later should work, but is not tested):
```
dotnet publish
```

# Example Output
<img width="400" height="400" alt="example" src="https://github.com/user-attachments/assets/73afa07c-119a-4f89-a33d-8bd0ce27e662" />
