#include "../../include/ui/UIManager.h"

UIManager::UIManager() {
    // Constructor
}

UIManager::~UIManager() {
    shutdown();
}

void UIManager::initialize() {
    // Initialize UI components and create window instances
}

void UIManager::run() {
    // Main loop to handle UI updates and events
    bool shouldRender = true;
    while (shouldRender) { //replace later with actual running condition
        for (auto& component : components) {
            component->update();
            component->render();
        }
        // Handle events

        // Redraw UI
    }
}

void UIManager::shutdown() {
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
