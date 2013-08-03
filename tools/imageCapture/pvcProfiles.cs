singleton GuiControlProfile (GuiPVCCaptureProfile)
{
   border = 2;
   borderThickness = 2;
   borderColorNA = "75 75 75 255";
   bevelColorHL = "255 0 255 255";
};

// Do not reuse this profile - It gets changed in real-time by the ic gui
singleton GuiControlProfile(GuiICBackgroundProfile)
{
   opaque = true;
   border = true;
   fillColor = "0 150 150";
   canKeyFocus = false;
   hasBitmapArray = false;
};
