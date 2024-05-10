#include "../../include/root/ApplicationManager.h"

ApplicationManager::ApplicationManager() {
    // Constructor 
    initialize();
    run();
}

ApplicationManager::~ApplicationManager() {
    // Destructor 
    shutdown();
}

void ApplicationManager::initialize() {
    ioManager.initialize();
    uiManager.initialize();
    //analysisManager.initialize();
}

// Main loop
void ApplicationManager::run() {
    bool shouldRender = true; //replace later with actual stoping condition
    while (shouldRender) {
        ioManager.processInputs();
        //uiManager.update();
        //analysisManager.analyzeData();
    }
}

void ApplicationManager::shutdown() {
    ioManager.shutdown();
    uiManager.shutdown();
    //analysisManager.shutdown();
}
