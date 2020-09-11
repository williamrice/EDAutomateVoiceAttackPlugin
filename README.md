# EDAutomateVoiceAttackProgram
## This plugin is under development and is in a very alpha state as new features are being added
A voice attack plug in to automate external elite programs such as pulling up inara directly to commodity, engineer, or module information. It is designed for use with OVR Drop in VR so you can open the external windows by voice command and never leave the headset or type anything.

***

# Installation
<ul>
<li>You must have chromedriver installed and set to a PATH variable. The best way to do this is to install a popular windows package manager Chocolatey on your system as it will automatically set the PATH variable.</li>
<li>Follow the install instructions at https://chocolatey.org/install</li>
<li>Verify that Chocolatey installed correctly by running the command <strong><em>choco</em></strong></li>
<a href="https://ibb.co/8r7VQHg"><img src="https://i.ibb.co/R3DWJqT/choco.png" alt="choco" border="0"></a>
<li>Open a command prompt as administrator and run the command <strong><em>choco install chromedriver</em></strong></li>
<li>Follow the prompts to install chromedriver</li>
<li>You can test that chromedriver is working by running the command <strong><em>chromedriver</em></strong></li>
<a href="https://ibb.co/p0CqJCt"><img src="https://i.ibb.co/gjsYzs5/chromedriver.png" alt="chromedriver" border="0"></a>
<li>Download the latest release of EDAutomate at https://github.com/lawen4cer/EDAutomateVoiceAttackProgram/releases</li>
<li>Navigate to your voiceattack installation folder and place the downloaded zip file into your Apps folder</li>
<li>Unzip the .zip folder to this directory and you should end up with a folder called Ed Automate inside your Apps folder</li>
<li>This Folder will contain several .Dll files and a folder called Voice Attack Profiles</li>
<li>Open VoiceAttack and navigate to the wrench icon in the lower right corner to access your settings</li>
<li>Make sure that the checkbox for Enable Plugin Support is chekced</li>
<li>Click on Plugin Manager and check the box for Ed Automate Plugin to enable it</li>
<li>Import the .vap file into Voice Attack which is located inside the Voice Attack Profiles folder inside the Ed Automate folder that is located inside your Apps folder within the Voice Attack install directory</li>
<li>That completes the basic installation for the plugin, follow the optional steps below to include this plugin with HCS or other plugins</li>
</ul>

***

## Optional further installation
+ Select the profile that you normally use within Voice Attack. I normally use Singularity with HCS Voicepacks
+ Click the edit profile button next to the profile name
+ This will spawn a new window, click the Options button at the top
+ Another window will pop up and you will see a section titled Include Commands from other profiles:
+ Click the button with ... on it
+ Another window will pop up, click the add button
+ Select the Edautomate profile that you imported
+ Confirm everything by clicking Ok, Apply, and Done as you see it until your back to the Voice Attack main screen
+ You are all set now, you will be able to call commands from this profile along with your normal Voice Attack profile, enjoy!

***

## Current commands

### Optional words will be referenced in the following format {optional}

- <strong>Focus {on} elite</strong> - This command will return focus to the Elite Dangerous game window should you loose focus at anytime
- <strong>Where can I [buy] [sell] {my} [Commodity Name]</strong> - This command will launch a google chrome web browser and navigate to the commodity page. It will then input your last known location that you exited supercruise at if available. If the location is not available, it will reference sol by default
  - Examples - "Where can I buy gold" "Where can I sell painite" "Where can I sell my void opals"
  
***
  
## OVR Drop Setup

- You must re-bind the show/hide overlay button to F2 inside OVR drop for the Show/Hide Overlay command to work. (Or you can edit the Voice Attack command to send whatever keybind to the app if you know what your doing)

### Current OVR Drop commmands
- <strong>Show overlay</strong> - This will show the overlay in your VR headset
- <strong>Hide overlay</strong> - This will hide the overlay in your VR headset and refocus on the Elite Dangerous game automatically

***

## Usage Tips
+ Once a browser window is spawned, it is best to leave it open in the background for best results. If you close the browser tab or the chromewebdriver, you will receive a slight delay on the next browser automation command. This is due to the timeout that the chromewebdriver has. I've yet to find a solution for this and neither has the internet. The webdriver has no way of knowing that the window was exited. I will only allow one instance of the webdriver to be instantiated for obvious performance reasons. Your best bet is to leave the opened webbrowser and chromewebdriver running in the background as you play. 

***

# Support
If you need support, feel free to add me on discord, lawen4cer#2866 <br/>
Bug reports should be posted at https://github.com/lawen4cer/EDAutomateVoiceAttackProgram/issues

## Credits
This application is using the following libraries:
- Selenium - https://www.toolsqa.com/
- Elite Dangerous Journal - https://github.com/MagicMau/EliteJournalReader

##### Shoutout to TonyZ for his desire for literally everything to be voiced controlled or automated as an inspiration for this project. TonyZ has been providing voluntary support for HCS Voicepacks and Voice Attack for many years. He is often found in their discords, offering support for first time users. Reach out to TonyZ via discord at TonyZ#6300 for any help you might need with configuring your Voice Attack to work at its full potential with Elite Dangerous. o7
