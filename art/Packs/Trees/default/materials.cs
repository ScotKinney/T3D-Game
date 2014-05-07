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


singleton Material(defaultTree_bark_material)
{
	mapTo = "defaulttree_bark-material";

	diffuseMap[0] = "art/Packs/Trees/Canopy/canopytree_bark_diffuse.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = "10";

	doubleSided = false;
	translucent = "1";
	translucentBlendOp = "None";
   pixelSpecular[0] = "1";
   materialTag0 = "Tree_Default";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

singleton Material(defaulttree_material)
{
	mapTo = "defaulttree-material";

	diffuseMap[0] = "art/Packs/Trees/Canopy/canopytree_diffuse_transparency.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   pixelSpecular[0] = "1";
   alphaTest = "1";
   alphaRef = "127";
   materialTag0 = "Tree_Default";
};

singleton Material(defaultTree_fronds_material)
{
   mapTo = "defaulttree_fronds-material";
   diffuseMap[0] = "art/Packs/Trees/default/defaulttree_frond_diffuse_transparency.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   pixelSpecular[0] = "0";
   translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "127";
   translucent = "1";
   materialTag0 = "Tree_Default";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

singleton Material(defaulttree_ColorEffectR27G177B88_material)
{
   mapTo = "ColorEffectR27G177B88-material";
   diffuseColor[0] = "0.105882 0.694118 0.345098 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Tree_Default";
};

