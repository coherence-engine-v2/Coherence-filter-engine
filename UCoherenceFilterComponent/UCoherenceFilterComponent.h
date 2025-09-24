#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "UCoherenceFilterComponent.generated.h"

USTRUCT()
struct FCoherenceRule
{
    GENERATED_BODY()

    UPROPERTY()
    FString Id;

    UPROPERTY()
    FString Message;

    UPROPERTY()
    bool bShouldPass;
};

UCLASS(ClassGroup=(Custom), meta=(BlueprintSpawnableComponent))
class YOURGAME_API UUCoherenceFilterComponent : public UActorComponent
{
    GENERATED_BODY()

public:
    UUCoherenceFilterComponent();

protected:
    virtual void BeginPlay() override;

public:
    UFUNCTION(BlueprintCallable, Category="Coherence")
    void RunCoherenceCheck();
};
