# Hide-Text-in-Image
## A cool program I made that hides text in an image.

The way it does it is by transforming the text into an image and then blends the two images together in to a png.
***
The first step is to create bitmap of the text. We can use only the last 2 bytes of any symbol. So we can cover the first 65 536 UTF8 characters without loss of information. After the text runs out random characters are used until reaching the end of the image.


![alt text](https://i.imgur.com/Wtn6o8i.png "The Text bitmap is mixed with the original image.")
---
The images are mix by avareging the 2 bytes that we use from the characters and green and blue valuse of our image.The red color's least significant bits are used to store the lost information after the avareging.


![alt text](https://i.imgur.com/vHxFgLa.png "The Text bitmap is mixed with the original image.")
---
As you can see we still have our image but due to the way the we store our bytes there is a noticeable redshift.
Red or Monochrome images are best suited to be used. They are undistinguishable after being used.  
![alt text](https://i.imgur.com/WjiSYiH.jpg "The final result")

To get our original text we just return step by step to begining using the original image as key. 
Because the text is not encrypted even if there image varries from the original we will still get fragments from the text.

All in all for every 3 bytes in the original image we hide 2 bytes of text. 
