//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------


//------------------------------------------------------------------------------
// LightAnimData
//------------------------------------------------------------------------------

datablock LightAnimData( NullLightAnim )
{   
   animEnabled = false;
};

datablock LightAnimData( FireLightAnim )
{
   brightnessA = 0.75;
   brightnessZ = 1;
   brightnessPeriod = 0.7;
   brightnessKeys = "annzzznnnzzzaznzzzz";
   brightnessSmooth = 0;
   offsetA[0] = "-0.05";
   offsetA[1] = "-0.05";
   offsetA[2] = "-0.05";
   offsetZ[0] = "0.05";
   offsetZ[1] = "0.05";
   offsetZ[2] = "0.05";
   offsetPeriod[0] = "1.25";
   offsetPeriod[1] = "1.25";
   offsetPeriod[2] = "1.25";
   offsetKeys[0] = "ahahaazahakayajza";
   offsetKeys[1] = "ahahaazahakayajza";
   offsetKeys[2] = "ahahaazahakayajza";
   rotKeys[0] = "";
   rotKeys[1] = "";
   rotKeys[2] = "";
   colorKeys[0] = "";
   colorKeys[1] = "";
   colorKeys[2] = "";
};

datablock LightAnimData( SubtlePulseLightAnim )
{
   brightnessA = 0.5;
   brightnessZ = 1;
   brightnessPeriod = 1;
   brightnessKeys = "aza";
   brightnessSmooth = true;
};

datablock LightAnimData( PulseLightAnim )
{   
   brightnessA = 0;
   brightnessZ = 1;
   brightnessPeriod = 1;
   brightnessKeys = "aza";
   brightnessSmooth = true;
};

datablock LightAnimData( FlickerLightAnim )
{
   brightnessA = 1;
   brightnessZ = 0;
   brightnessPeriod = 5;
   brightnessKeys = "aaazaaaaaazaaazaaazaaaaazaaaazzaaaazaaaaaazaaaazaaaza";
   brightnessSmooth = false;
};

datablock LightAnimData( BlinkLightAnim )
{
   brightnessA = 0;
   brightnessZ = 1;
   brightnessPeriod = 5;
   brightnessKeys = "azaaaazazaaaaaazaaaazaaaazzaaaaaazaazaaazaaaaaaa";
   brightnessSmooth = false;
};

datablock LightAnimData( SpinLightAnim )
{
   rotA[2] = "0";
   rotZ[2] = "360";
   rotPeriod[2] = "1";
   rotKeys[2] = "az";
   rotSmooth[2] = true;
};
