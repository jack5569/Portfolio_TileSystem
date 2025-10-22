# Modular Grid System
A portfolio project demonstrating a flexible, data-driven grid and snapping framework for Unity.

## Overview
A modular, data-driven grid system featuring a custom editor tool for layout creation and a runtime snapping system with overlap detection.

## Features
- Grid Editor - Create and edit grid layouts directly in the Unity Editor, then export them as data assets for runtime use.
- Runtime Loading - Load and reconstruct grid layouts dynamically from exported data.
- Snapping System - Drag & drop objects that automatically align to grid cells.
- Overlap Detection - Detect and prevent conflicting placements for objects of varying sizes.

## Demo
![Editor Demo](/Medias/EditorDemo.gif)
Design and export grid layouts directly as reusable data assets.

![Runtime Demo](/Medias/RuntimeDemo.gif)
Demonstrates runtime loading, snapping behavior, and overlap detection.

## Setup / How to Run
1. Clone or download the project.
2. Open in Unity
3. Open `Assets/Scene/01_GridDataEditor.unity` to test the editor tool.
4. Open `Assets/Scene/02_RuntimeDemo.unity` to test runtime loading, snapping, and overlap detection.

## Professional Background
This system is a reimplementation of one I originally designed during my professional work experience. All code and assets were recreated from scratch for portfolio demonstration purposes.

## Tech Stack
- Unity 2022.3.49f1
- ScriptableObjects
- Custom Editor Tools
- Personal Framework Utilities

## Credits
- [DOTween](https://github.com/Demigiant/dotween) - Used for basic tweening and animation transitions.
- [Isometric Tower Defense Pack](https://artyom-zagorskiy.itch.io/isometric-tower-defense-pack-az) - Used for placeholder art assets for runtime demo scene.
