#include "UIManager.h"

UIManager::UIManager() {
    // Constructor
}

UIManager::~UIManager() {
    shutdown();
}

void UIManager::initialize() {
    // Initialize UI components
    // For example, load resources or create window instances
}

void UIManager::run() {
    // Main loop to handle UI updates and events
    while (true) { // Replace with a proper condition to exit the loop
        for (auto& component : components) {
            component->update();
            component->render();
        }
        // Handle events (mouse, keyboard, etc.)

        // Redraw UI if necessary
    }
}

void UIManager::shutdown() {
    // Clean up resources and shut down UI components
    components.clear();
}

void UIManager::addComponent(std::unique_ptr<BaseComponent> component) {
    components.push_back(std::move(component));
}

void UIManager::removeComponent(BaseComponent* component) {
    components.erase(std::remove_if(components.begin(), components.end(),
        [component](const std::unique_ptr<BaseComponent>& c) { return c.get() == component; }),
        components.end());
}

