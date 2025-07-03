Count Vertical Lines - Console App

USAGE:
Run the application from the command line, passing the absolute path to the image file.

Example:

Build:
  Open the solution in Visual Studio or build via CLI:
    > dotnet build

Open a terminal (e.g., Command Prompt).
Navigate to the output directory:
   
   Executable path after building in Release mode:
   > CountVerticalLines\bin\Release\net8.0\CountVerticalLines.exe

   Or for Debug mode:
   > CountVerticalLines\bin\Debug\net8.0\CountVerticalLines.exe

> CountVerticalLines.exe "C:\TMMC_interview_assignment\img_1.jpg"

Description:
  This application counts the number of vertical black lines in a black-and-white image
  created using MS Paint. A vertical line is assumed to be a column that contains at
  least one black pixel, and connected black columns are counted as a single line.

Requirements:
  - Input must be a .jpg image created using MS Paint.
  - Background is white. Lines are black, drawn using bucket tool.
  - Lines are continuous (exist on top and bottom of image).

Build:
  Open the solution in Visual Studio or build via CLI:
    > dotnet build

Open a terminal (e.g., Command Prompt).
Navigate to the output directory:
   
   Executable path after building in Release mode:
   > CountVerticalLines\bin\Release\net8.0\CountVerticalLines.exe

   Or for Debug mode:
   > CountVerticalLines\bin\Debug\net8.0\CountVerticalLines.exe

Run:
  > CountVerticalLines.exe "C:\TMMC_interview_assignment\img_1.jpg"

NOTES:
- The image must be a black-and-white image created with MS Paint.
- Vertical lines must be straight and continuous from top to bottom.
- Black pixels are detected using a threshold(less than 50) to account for JPG artifacts.