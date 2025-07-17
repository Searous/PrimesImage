using System.Drawing;

// Variables
const string OutputPath = "primes.png";
int imageSize = 1024;
int pixelCount;
Color notPrimeColor = Color.Gray;
Color primeColor = Color.Gold;

// Read user input
string? input = null;
while(input == null) { // Loop here until the user inputs a valid input
    // Prompt user and wait for input
    Console.Write("Desired image size (both width and height): ");
    input = Console.ReadLine();

    // Try to parse the input as an int
    // If failed, tell the user parsing failed, and set input to null so we loop again
    // imageSize will be set if the parse is successful
    if(!int.TryParse(input, out imageSize)) {
        Console.WriteLine("Failed to parse input string, try again");
        input = null;
    }
}

// Calculate pixel count
pixelCount = imageSize * imageSize;

// The image we're writing to
Bitmap image = new Bitmap(imageSize, imageSize);

// Final message before doing the actual work
Console.WriteLine("Creating primes image...");
var cursorPos = Console.GetCursorPosition(); // Grab the cursor position so we can show the progress line correctly

// Iterate over every pixel and color it based on if the number 'i' is prime or not,
// wrapping at the edges to count each pixel
for(int i = 0; i < imageSize * imageSize; i++) {
    // Write progress line
    Console.SetCursorPosition(cursorPos.Left, cursorPos.Top);
    string percentageComplete = ((i + 1.0f) / (pixelCount) * 100.0f).ToString("F2");
    Console.Write($"Drawing pixel {i + 1} of {pixelCount} ({percentageComplete}% complete)...");

    // Check if prime, if yes color the pixel and move on. If no, use the other pixel color instead
    if(IsPrime(i + 1)) {
        image.SetPixel(i % imageSize, i / imageSize, primeColor);
        continue;
    }
    image.SetPixel(i % imageSize, i / imageSize, notPrimeColor);
}

// Save image
Console.WriteLine($"\nSaving primes image to \'{Path.GetFullPath(OutputPath)}\'");
image.Save("primes.png");

// Tell the user the process is finished then prompt for input and exit after
Console.WriteLine("Done! Press any key to exit...");
Console.ReadKey();

// Prime function
// Returns true if 'n' is prime
static bool IsPrime(int n) {
    if(n <= 1) return false;        // Skip if n is too low to be prime or is negative
    if(n == 2) return true;         // Return true here if n is 2, the only even prime
    if(n % 2 == 0) return false;    // Skip if n is an even number other than 2

    // The upper bound to check to (square root of n)
    int bound = (int) Math.Floor(Math.Sqrt(n));

    // Check if n isn't prime, starting from 3, skipping even numbers, and only checking numbers less than or equal to bound
    // If the remainder of n / i equals 0, this means that n is divisible by i and therefore isn't prime
    for(int i = 3; i <= bound; i += 2) {
        if(n % i == 0) return false;
    }

    // This is only reachable if n is prime
    return true;
}
