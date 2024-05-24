#include "../../include/ui/UIManager.h"
#include "lvgl/lvgl.h"
#include "lv_drivers/display/monitor.h"
#include "lv_drivers/indev/mouse.h"

UIManager::UIManager() {
    lvglSetup();
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
    while (shouldRender) { // Replace later with actual running condition
        for (auto& component : components) {
            component->update();
            component->render();
        }
        // Handle events

        // Redraw UI
        lv_timer_handler();  // Changed from lv_task_handler() to lv_timer_handler()
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

void UIManager::lvglSetup() {
    lv_init();

    // Monitor setup
    static lv_disp_draw_buf_t draw_buf;
    static lv_color_t buf1[LV_HOR_RES_MAX * 10];
    lv_disp_draw_buf_init(&draw_buf, buf1, nullptr, LV_HOR_RES_MAX * 10);

    static lv_disp_drv_t disp_drv;
    lv_disp_drv_init(&disp_drv);
    disp_drv.draw_buf = &draw_buf;
    disp_drv.flush_cb = monitorFlush;
    disp_drv.hor_res = 480;
    disp_drv.ver_res = 320;
    lv_disp_drv_register(&disp_drv);

    // Mouse setup
    static lv_indev_drv_t indev_drv;
    lv_indev_drv_init(&indev_drv);
    indev_drv.type = LV_INDEV_TYPE_POINTER;
    indev_drv.read_cb = mouseRead;
    lv_indev_drv_register(&indev_drv);
}

void UIManager::monitorFlush(lv_disp_drv_t* disp_drv, const lv_area_t* area, lv_color_t* color_p) {
    monitor_flush(disp_drv, area, color_p);
}

bool UIManager::mouseRead(lv_indev_drv_t* indev_drv, lv_indev_data_t* data) {
    mouse_read(nullptr, data);
    return false;
}
