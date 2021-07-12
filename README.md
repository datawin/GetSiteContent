# Get Site Content

This is an ASP.Net MVC web application programmed in C#. With inputting a web page url, it displays all scrapped images in a carousel and top 10 occurring words with their counts in a grid view.

Since more and more newer JavaScript technologies using dynamic JavaScript code, a regular HTTP request won’t return parsed HTML. So instead of using HTML Agility Pack for parsing raw HTML, which is very popular to scrape a static page html, this application use Selenium WebDriver to render a page and then parse the results. Selenium WebDriver is commonly used in automated testing tool.

When using NuGet to install Selenium.WebDriver and Selenium.WebDriver.ChromeDriver (for Headless Chrome), make sure to use the same version as binary (for example: "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"). If you prefer other browser, Selenium also has drivers for other popular browsers such as FireFox.

Libraries and Components:
Selenium WebDriver; 
Bootstrap Carousel; 
Webgrid
