# Moonwave.SATNET
A wrapper for the WinSAT API.

Moonwave.SATNET is a WinSAT API wrapper that allows you to easily retrieve computer performance and assessment state information from WinSAT. This allows developers to determine optimal application and video game settings based on a computers performance capabilities using data provided by WinSAT.

Microsoft not only uses WinSAT as a way to adjust the performance of Windows based on a computers performance capabilities, they also provided an API for developers to do the same with their applications and games as well.

## Understanding WinSAT:

WinSAT first shipped starting with Windows Vista. During the installation process of Vista and later, a formal WinSAT assessment is ran. In later versions of Windows, an assessment is ran in the background regularly based on a set schedule. This serves as a benchmark in order for Windows to determine optimal system and performance settings including visual effects such as Aero. In earlier versions of Windows, the Windows Experience Index application could be used to review a systems base score and several subscores across different hardware categories. A systems base score is always equal to the lowest subscore, indicating which component should be upgraded first. It wasn’t until Windows 8.1 when Microsoft removed the Windows Experience Index application. Different versions of Windows have a different range of minimum to maximum scores.

Windows Vista: 1.0 - 5.9  
Windows 7: 1.0 - 7.9  
Windows 8 and later: 1.0 - 9.9  

## Using:

### Retrieving assessment state:

```c#
AssesmentState assesmentState = Assesment.State;

if (assesmentState == AssesmentState.Valid)
{
    // There is a valid WinSAT assesment available and valid.
}
```

#### Or:

```c#
if (Assesment.State == AssesmentState.Valid)
{
    // There is a valid WinSAT assesment available and valid.
}
```

### Retrieving assesment scores:

```c#
float cpuScore = 0f;

if (Assesment.State == AssesmentState.Valid)
{
    cpuScore = Assesment.CPUScore;
}
```

### Putting it together (using Unity3D):

```c#
private void AutoDetect()
{
    if (Assesment.State == AssesmentState.Valid)
    {
        float d3dScore = Assesment.D3DScore;

        if (d3dScore >= 1.0f && d3dScore <= 3.3f)
        {
            // Low settings.
            QualitySettings.SetQualityLevel(0, false);
        }
        else if (d3dScore >= 3.3f && d3dScore <= 6.6f)
        {
            // Medium settings.
            QualitySettings.SetQualityLevel(1, false);
        }
        else
        {
            // Max settings.
            QualitySettings.SetQualityLevel(2, false);
        }
    }
    else
    {
        // An assesment is not available to read from. Here you would use another method.
    }
}
```
This is just a very basic example. For production it is recommended to adjust individual settings of your game based on the hardware that is used. Textures are rendered using the GPU and anti aliasing (depending on the method) uses the CPU.
### An example application made for demonstration purposes:
![An example project created using SATNET.](https://www.dl.dropboxusercontent.com/s/48bl16gaz5ep8bo/Photo%20Mar%2013%2C%207%2053%2051%20PM.jpg?dl=1)

## Requirements:
Windows Vista and later.

## Disclaimer:

WinSAT should not be used for applications with the sole purpose of benchmarking. WinSAT determines hardware scores by running tests that reflect daily to intense operations calculated by time. It does not measure how good a computer is, it provides a bare measurement of what a computer can do efficiently and provides results based on what could happen. Other benchmarking software is far more complex and demanding. They provide results based on what is happening and the intensity varies amongst the several vendors.
