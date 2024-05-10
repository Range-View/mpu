#pragma once

#include "../UI/UIManager.h"
#include "../IO/IOManager.h"
//#include "include/analysis/AnalysisManager.h"


class ApplicationManager {
public:
    ApplicationManager();
    ~ApplicationManager();

    void initialize();
    void run();
    void shutdown();

private:
    UIManager uiManager;
    IOManager ioManager;
    //AnalysisManager analysisManager;
};
