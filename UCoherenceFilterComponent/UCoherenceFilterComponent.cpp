#include "UCoherenceFilterComponent.h"
#include "Misc/FileHelper.h"
#include "Misc/Paths.h"
#include "Json.h"

UUCoherenceFilterComponent::UUCoherenceFilterComponent()
{
    PrimaryComponentTick.bCanEverTick = false;
}

void UUCoherenceFilterComponent::BeginPlay()
{
    Super::BeginPlay();
    RunCoherenceCheck();
}

void UUCoherenceFilterComponent::RunCoherenceCheck()
{
    FString FilePath = FPaths::ProjectContentDir() + TEXT("CoherenceRuleSet.json");
    FString JsonRaw;

    if (!FFileHelper::LoadFileToString(JsonRaw, *FilePath))
    {
        UE_LOG(LogTemp, Error, TEXT("[Coherence] Failed to load rule file: %s"), *FilePath);
        return;
    }

    TSharedRef<TJsonReader<>> Reader = TJsonReaderFactory<>::Create(JsonRaw);
    TSharedPtr<FJsonObject> JsonObject;

    if (FJsonSerializer::Deserialize(Reader, JsonObject) && JsonObject.IsValid())
    {
        const TArray<TSharedPtr<FJsonValue>>* Rules;
        if (
