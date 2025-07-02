Vertical Line Counter Console App

USAGE:
Run the application from the command line, passing the absolute path to the image file.

Example:
> VerticalLineCounter.exe "C:\TMMC_interview_assignment\img_1.jpg"

OUTPUT:
Prints the number of vertical black lines found in the image.

NOTES:
- The image must be a black-and-white image created with MS Paint.
- Vertical lines must be straight and continuous from top to bottom.
- Black pixels are detected using a threshold(less than 50) to account for JPG artifacts.