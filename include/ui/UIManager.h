#pragma once

#include <vector>
#include <memory>
#include "components/BaseComponent.h"
#include "lvgl/lvgl.h"        
#include "lv_drivers/display/monitor.h"
#include "lv_drivers/indev/mouse.h"


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

private:
    void lvglSetup();
    static void monitorFlush(lv_disp_drv_t* disp_drv, const lv_area_t* area, lv_color_t* color_p);
    static void mouseRead(lv_indev_drv_t* indev_drv, lv_indev_data_t* data);
};
