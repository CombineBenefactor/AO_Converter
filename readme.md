# AO Converter

A simple Windows application that converts Half-Life: Alyx / Source 2 ORM mask textures into separate Metallic, Roughness, and Ambient Occlusion (AO) maps for use in Roblox. Drag a texture onto the `.exe` file, and it will automatically generate the maps in the same folder, scaling down any images larger than 1024×1024.

[Download here](https://github.com/CombineBenefactor/AO_Converter/releases)

## Features
- Automatically extracts **Metallic**, **Roughness**, and **AO** channels from HLA ORM textures.  
- Supports only **PNG** input files.  
- Downscales textures larger than 1024×1024 to reduce file size and improve performance in Roblox.  
- Simple drag-and-drop interface — just drag the image onto the `.exe`.

## Requirements
- Windows  
- .NET 8.0+ Runtime

## Installation
1. Download the compiled `AO_Converter.exe` from this repository.  
2. Place it in any folder where you want to process textures.  

## Usage
1. Open the folder containing `AO_Converter.exe`.  
2. Drag any Source 2 / HLA ORM PNG texture onto the executable.  
3. The program will:
   - Optionally downscale images larger than 1024×1024.  
   - Extract the **Metallic**, **Roughness**, and **AO** maps from the correct color channels.  
   - Output new PNG files in the same folder, named based on the original file (e.g., `cardboard_box_1_metallic.png`).  

## Notes
- Only the compiled `.exe` is provided; source code is available in this repository.  
- The program does **not** modify the original files.  
- Dragging multiple files is not supported; process one at a time.  
- The tool is designed specifically for Source 2 / HLA ORM textures; other PNGs may not produce meaningful results.
