#pragma once

#include "BaseComponent.h"
#include <vector>
#include <memory>

class UIManager {
private:
    std::vector<std::unique_ptr<BaseComponent>> components;

public:
    UIManager();
    ~UIManager();

    // Initializes the UI components
    void initialize();

    // Main loop for UI updates and event handling
    void run();

    // Shuts down the UI manager and cleans up resources
    void shutdown();

    // Methods to manage UI components
    void addComponent(std::unique_ptr<BaseComponent> component);
    void removeComponent(BaseComponent* component);

};
