#pragma once
#include <string>

class ConfigManager {
public:
    bool loadConfig(const std::string& filePath);
    std::string getValue(const std::string& key);
};
