#pragma once
#include <string>

class Logger {
public:
    static void logMessage(const std::string& message);
    static void logError(const std::string& error);
};
