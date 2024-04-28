#pragma once

#include <string>

// Interface for UI components
class BaseComponent {
public:
    virtual ~BaseComponent() = default;

    // Method to render the component
    virtual void render() = 0;

    // Method to update the component, e.g., in response to events
    virtual void update() = 0;

    // Methods for event handling
    // virtual void onMouseClick(int x, int y) = 0;
    // virtual void onKeyPress(int key) = 0;

};
