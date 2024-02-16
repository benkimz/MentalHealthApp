using MentalHealthApp.PWA.Data.Enums;
using MentalHealthApp.PWA.Data.Interfaces;
using MentalHealthApp.PWA.Data.Models;

namespace MentalHealthApp.PWA.Data
{
    public class VideoContentService : IVideoContentService
    {
        private IEnumerable<VideoContent> videos => new List<VideoContent>
        {
            // Anger category
            new VideoContent
    {
        Step = 1,
        Title = "Understanding Anger",
        Body = "Anger is a normal and healthy emotion that can help us cope with challenges and protect ourselves from harm. However, when anger becomes too intense, frequent, or destructive, it can negatively affect our health, relationships, and well-being.",
        TextPrompt = "What are some situations that make you feel angry?",
        VideoUrl = VideoUrl(362123047),
        PdfUrl = "[2]",
        VideoName = "Understanding_Anger.mp4",
        Category = ContentCategory.Anger
    },new VideoContent
    {
        Step = 2,
        Title = "Managing Anger",
        Body = "Managing anger is not about suppressing or denying it, but rather learning how to express it in healthy and constructive ways. There are many strategies that can help us manage our anger, such as breathing exercises, relaxation techniques, cognitive restructuring, problem-solving, and assertive communication.",
        TextPrompt = "What are some strategies that you use or want to try to manage your anger?",
        VideoUrl = VideoUrl(292395064),
        PdfUrl = "[4]",
        VideoName = "Managing_Anger.mp4",
        Category = ContentCategory.Anger
    },new VideoContent
    {
        Step = 3,
        Title = "Dealing with Angry People",
        Body = "Dealing with angry people can be challenging and stressful, especially if their anger is directed at us. However, there are some tips that can help us handle these situations more effectively, such as staying calm, listening empathically, validating their feelings, setting boundaries, and seeking help if needed.",
        TextPrompt = "How do you usually react when someone is angry with you?",
        VideoUrl = VideoUrl(362134114),
        PdfUrl = "[6]",
        VideoName = "Dealing_with_Angry_People.mp4",
        Category = ContentCategory.Anger
    },new VideoContent
    {
        Step = 4,
        Title = "Anger and Forgiveness",
        Body = "Anger and forgiveness are two powerful emotions that can have a significant impact on our well-being. Anger can keep us stuck in the past and prevent us from moving on, while forgiveness can free us from resentment and bitterness and allow us to heal and grow.",
        TextPrompt = "What are some benefits of forgiving yourself and others?",
        VideoUrl = VideoUrl(362134114),
        PdfUrl = "[8]",
        VideoName = "Anger_and_Forgiveness.mp4",
        Category = ContentCategory.Anger
    },new VideoContent
    {
        Step = 5,
        Title = "Anger and Happiness",
        Body = "Anger and happiness are two opposite emotions that can influence each other. Anger can reduce our happiness and make us feel more negative, while happiness can reduce our anger and make us feel more positive. Therefore, it is important to find a balance between these emotions and cultivate more happiness in our lives.",
        TextPrompt = "What are some things that make you happy?",
        VideoUrl = VideoUrl(362129741),
        PdfUrl = "[10]",
        VideoName = "Anger_and_Happiness.mp4",
        Category = ContentCategory.Anger
    },
    // Anxiety category
    new VideoContent
    {
        Step = 1,
        Title = "Understanding Anxiety",
        Body = "Anxiety is a normal and natural response to situations that are perceived as threatening or uncertain. Anxiety can help us prepare for challenges and motivate us to perform well. However, when anxiety becomes too intense, frequent, or persistent, it can interfere with our daily functioning and cause distress.",
        TextPrompt = "What are some situations that make you feel anxious?",
        VideoUrl = VideoUrl(362707415),
        PdfUrl = "[12]",
        VideoName = "Understanding_Anxiety.mp4",
        Category = ContentCategory.Anxiety
    },
    new VideoContent
    {
        Step = 2,
        Title = "Managing Anxiety",
        Body = "Managing anxiety is not about eliminating or avoiding it, but rather learning how to cope with it in healthy and adaptive ways. There are many strategies that can help us manage our anxiety, such as breathing exercises, relaxation techniques, cognitive restructuring, exposure therapy, and mindfulness.",
        TextPrompt = "What are some strategies that you use or want to try to manage your anxiety?",
        VideoUrl = VideoUrl(285885756),
        PdfUrl = "[14]",
        VideoName = "Managing_Anxiety.mp4",
        Category = ContentCategory.Anxiety
    },new VideoContent
    {
        Step = 3,
        Title = "Dealing with Anxious People",
        Body = "Dealing with anxious people can be challenging and frustrating, especially if their anxiety affects us or our relationship with them. However, there are some tips that can help us deal with these situations more effectively, such as being supportive, empathic, patient, and encouraging.",
        TextPrompt = "How do you usually react when someone is anxious around you?",
        VideoUrl = VideoUrl(362725307),
        PdfUrl = "[16]",
        VideoName = "Dealing_with_Anxious_People.mp4",
        Category = ContentCategory.Anxiety
    },new VideoContent
    {
        Step = 4,
        Title = "Anxiety and Self-Esteem",
        Body = "Anxiety and self-esteem are two interrelated concepts that can affect each other. Anxiety can lower our self-esteem and make us feel more insecure, while low self-esteem can increase our anxiety and make us more vulnerable to stress. Therefore, it is important to improve our self-esteem and confidence in ourselves.",
        TextPrompt = "What are some things that you like or appreciate about yourself?",
        VideoUrl = VideoUrl(362783278),
        PdfUrl = "[18]",
        VideoName = "Anxiety_and_Self-Esteem.mp4",
        Category = ContentCategory.Anxiety
    },new VideoContent
    {
        Step = 5,
        Title = "Anxiety and Happiness",
        Body = "Anxiety and happiness are two opposite emotions that can influence each other. Anxiety can reduce our happiness and make us feel more negative, while happiness can reduce our anxiety and make us feel more positive. Therefore, it is important to find a balance between these emotions and cultivate more happiness in our lives.",
        TextPrompt = "What are some things that make you happy?",
        VideoUrl = VideoUrl(288040319),
        PdfUrl = "[20]",
        VideoName = "Anxiety_and_Happiness.mp4",
        Category = ContentCategory.Anxiety
    },
    // Depression category
    new VideoContent
    {
        Step = 1,
        Title = "Understanding Depression",
        Body = "Depression is a common and serious mental health condition that affects how we feel, think, and act. Depression can cause persistent feelings of sadness, hopelessness, and loss of interest in activities that we used to enjoy. Depression can also affect our physical health, sleep, appetite, energy, and concentration.",
        TextPrompt = "What are some signs or symptoms of depression that you have experienced or noticed in others?",
        VideoUrl = VideoUrl(321847129),
        PdfUrl = "[22]",
        VideoName = "Understanding_Depression.mp4",
        Category = ContentCategory.Depression
    },new VideoContent
    {
        Step = 2,
        Title = "Managing Depression",
        Body = "Managing depression is not about snapping out of it or pretending to be happy, but rather seeking professional help and following a treatment plan that works for us. There are many effective treatments for depression, such as medication, psychotherapy, lifestyle changes, and self-help techniques.",
        TextPrompt = "What are some treatments or coping skills that you have used or want to try to manage your depression?",
        VideoUrl = VideoUrl(285009245),
        PdfUrl = "[24]",
        VideoName = "Managing_Depression.mp4",
        Category = ContentCategory.Depression
    },new VideoContent
    {
        Step = 3,
        Title = "Dealing with Depressed People",
        Body = "Dealing with depressed people can be difficult and draining, especially if they are our loved ones or close friends. However, there are some tips that can help us support them and show them that we care, such as being present, listening, expressing empathy, offering help, and encouraging them to seek treatment.",
        TextPrompt = "How do you usually react when someone is depressed around you?",
        VideoUrl = VideoUrl(362723006),
        PdfUrl = "[26]",
        VideoName = "Dealing_with_Depressed_People.mp4",
        Category = ContentCategory.Depression
    },new VideoContent
    {
        Step = 4,
        Title = "Depression and Self-Esteem",
        Body = "Depression and self-esteem are two interrelated concepts that can affect each other. Depression can lower our self-esteem and make us feel more insecure, while low self-esteem can increase our depression and make us more vulnerable to stress. Therefore, it is important to improve our self-esteem and confidence in ourselves.",
        TextPrompt = "What are some things that you like or appreciate about yourself?",
        VideoUrl = VideoUrl(289760468),
        PdfUrl = "[28]",
        VideoName = "Depression_and_Self-Esteem.mp4",
        Category = ContentCategory.Depression
    },new VideoContent
    {
        Step = 5,
        Title = "Depression and Happiness",
        Body = "Depression and happiness are two opposite emotions that can influence each other. Depression can reduce our happiness and make us feel more negative, while happiness can reduce our depression and make us feel more positive. Therefore, it is important to find a balance between these emotions and cultivate more happiness in our lives.",
        TextPrompt = "What are some things that make you happy?",
        VideoUrl = VideoUrl(362724629),
        PdfUrl = "[30]",
        VideoName = "Depression_and_Happiness.mp4",
        Category = ContentCategory.Depression
    },
    // Guilt category
    new VideoContent
    {
        Step = 1,
        Title = "Understanding Guilt",
        Body = "Guilt is a complex and often unpleasant emotion that involves feeling responsible or regretful for a perceived or real wrongdoing. Guilt can help us learn from our mistakes and improve our moral behavior. However, when guilt becomes excessive, irrational, or chronic, it can harm our self-esteem, relationships, and well-being.",
        TextPrompt = "What are some situations that make you feel guilty?",
        VideoUrl = VideoUrl(751301521),
        PdfUrl = "[32]",
        VideoName = "Understanding_Guilt.mp4",
        Category = ContentCategory.Guilt
    },new VideoContent
    {
        Step = 2,
        Title = "Managing Guilt",
        Body = "Managing guilt is not about denying or ignoring it, but rather acknowledging it and taking appropriate action to resolve it. There are many strategies that can help us manage our guilt, such as apologizing, making amends, forgiving ourselves, challenging distorted thoughts, and seeking professional help if needed.",
        TextPrompt = "What are some strategies that you use or want to try to manage your guilt?",
        VideoUrl = VideoUrl(283520345),
        PdfUrl = "[34]",
        VideoName = "Managing_Guilt.mp4",
        Category = ContentCategory.Guilt
    },new VideoContent
    {
        Step = 3,
        Title = "Dealing with Guilty People",
        Body = "Dealing with guilty people can be challenging and sensitive, especially if they have hurt us or someone we care about. However, there are some tips that can help us deal with these situations more effectively, such as being compassionate, respectful, honest, and assertive.",
        TextPrompt = "How do you usually react when someone is guilty around you?",
        VideoUrl = VideoUrl(751307361),
        PdfUrl = "[36]",
        VideoName = "Dealing_with_Guilty_People.mp4",
        Category = ContentCategory.Guilt
    },new VideoContent
    {
        Step = 4,
        Title = "Guilt and Self-Esteem",
        Body = "Guilt and self-esteem are two interrelated concepts that can affect each other. Guilt can lower our self-esteem and make us feel more unworthy, while low self-esteem can increase our guilt and make us more prone to self-blame. Therefore, it is important to improve our self-esteem and confidence in ourselves.",
        TextPrompt = "What are some things that you like or appreciate about yourself?",
        VideoUrl = VideoUrl(751310043),
        PdfUrl = "[38]",
        VideoName = "Guilt_and_Self-Esteem.mp4",
        Category = ContentCategory.Guilt
    },new VideoContent
    {
        Step = 5,
        Title = "Guilt and Happiness",
        Body = "Guilt and happiness are two opposite emotions that can influence each other. Guilt can reduce our happiness and make us feel more negative, while happiness can reduce our guilt and make us feel more positive. Therefore, it is important to find a balance between these emotions and cultivate more happiness in our lives.",
        TextPrompt = "What are some things that make you happy?",
        VideoUrl = VideoUrl(751305456),
        PdfUrl = "[40]",
        VideoName = "Guilt_and_Happiness.mp4",
        Category = ContentCategory.Guilt
    }
        };

        public Task<IEnumerable<VideoContent>?> GetAngerVideos()
        {
            return Task.FromResult(videos.Where(q => q.Category == ContentCategory.Anger) ?? null);
        }

        public Task<IEnumerable<VideoContent>?> GetAnxietyVideos()
        {
            return Task.FromResult(videos.Where(q => q.Category == ContentCategory.Anxiety) ?? null);
        }

        public Task<IEnumerable<VideoContent>?> GetDepressionVideos()
        {
            return Task.FromResult(videos.Where(q => q.Category == ContentCategory.Depression) ?? null);
        }

        public Task<IEnumerable<VideoContent>?> GetGuiltVideos()
        {
            return Task.FromResult(videos.Where(q => q.Category == ContentCategory.Guilt) ?? null);
        }

        // ~ helper methods
        private string VideoUrl(int videoId) => $"https://player.vimeo.com/video/{videoId}";
    }
}
