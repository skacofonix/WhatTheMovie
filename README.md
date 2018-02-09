What the Movie
==========

This project is under MIT License.
Please see the license detail for more informations.

*v2 coming soon !*

## Introduction

WhatTheMovie is a great website when you play to find movie with snapshot.

  See http://whatthemovie.com/

Unfortunately this website does not offer mobile version, only a version for desktop PC.
But today the use of the web is nomadic with smartphone or tablet.
The current site is not adapted to the specificities of these mobile devices.

The idea is therefore to provide a mobile version of this website.
But even doing that well, so make a native mobile application rather than just a mobile website.


## Let's go!

The goal of this project : a mobile native application for WhatTheMovie targeted Android, then Windows Phone and iOS later.

I choose Xamarin to provide cross plateform tool.

You can use Xamarin Open Source Project Subscription for a complete business license. http://resources.xamarin.com/open-source-contributor.html


## API first

There is no API provided by WhatTheMovie.com.
The only way to retrieve data from the website is to parse it.
It's ugly, not always very effective, but it works!

To do that the more "cleanly" as possible, it is necessary to set up an unofficial API.
This homemade API offer WhatTheMovie service across REST interface.

Furthermore, this API can be used by another application.

You can try it : http://wtmapi.azurewebsites.net/api/Shot
